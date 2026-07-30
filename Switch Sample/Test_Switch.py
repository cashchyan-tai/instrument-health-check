"""
RF Switch Box - LAN Control Sample Code
Device: Pega RF Switch Box (P5-SWB series) - 2SP6T
Communication: HTTP over LAN (TCP/IP)

Network layout:
  Switch (HTTP SCPI) : 192.168.0.100:80   <-- direct control, use this
  S2E bridge         : 192.168.1.150:23   <-- serial bridge, NOT for HTTP SCPI
"""

import socket
import time
from urllib.request import urlopen


# ─── Configuration ────────────────────────────────────────────────────────────
SWITCH_IP      = "192.168.100.250"  # RF Switch Box direct IP
HTTP_PORT      = 80
TELNET_PORT    = 23
TIMEOUT_SEC    = 3
SWITCH_NAME    = "A"               # SP6T switch name: A or B
# ──────────────────────────────────────────────────────────────────────────────


class RFSwitchBoxHTTP:
    """Control RF Switch Box via HTTP (GET request)."""

    def __init__(self, ip: str = SWITCH_IP, port: int = HTTP_PORT):
        self.ip   = ip
        self.port = port
        self.base = f"http://{ip}" if port == 80 else f"http://{ip}:{port}"

    def send(self, command: str) -> str:
        url = f"{self.base}/{command}"
        print(f"[CMD] {command}")
        try:
            data = urlopen(url, timeout=TIMEOUT_SEC).read()
            if len(data) > 100:
                print(f"[HTTP] Unexpected HTML response for: {command}")
                return ""
            return data.rstrip(b"\x00").decode("ascii", errors="replace").strip()
        except Exception as e:
            print(f"[HTTP Error] {e}")
            return ""

    # ── Device info ──────────────────────────────────────────────────────────

    def get_idn(self) -> str:
        return self.send("*IDN?")

    def get_model(self) -> str:
        return self.send("MN?")

    def get_serial(self) -> str:
        return self.send("SN?")

    def get_firmware(self) -> str:
        return self.send("FIRMWARE?")

    # ── SP6T control (state: 0=disconnect, 1-6=port) ─────────────────────────

    def set_port1(self, switch: str = SWITCH_NAME) -> str:
        """Connect SP6T Com to Port 1."""
        resp = self.send(f"SP6T{switch.upper()}:STATE:1")
        if resp == "1":
            print(f"[SP6T{switch.upper()}] -> Port 1")
        else:
            print(f"[SP6T{switch.upper()}] set Port 1 failed: {resp}")
        return resp

    def set_port2(self, switch: str = SWITCH_NAME) -> str:
        """Connect SP6T Com to Port 2."""
        resp = self.send(f"SP6T{switch.upper()}:STATE:2")
        if resp == "1":
            print(f"[SP6T{switch.upper()}] -> Port 2")
        else:
            print(f"[SP6T{switch.upper()}] set Port 2 failed: {resp}")
        return resp

    def set_port3(self, switch: str = SWITCH_NAME) -> str:
        """Connect SP6T Com to Port 3."""
        resp = self.send(f"SP6T{switch.upper()}:STATE:3")
        if resp == "1":
            print(f"[SP6T{switch.upper()}] -> Port 3")
        else:
            print(f"[SP6T{switch.upper()}] set Port 3 failed: {resp}")
        return resp

    def set_port6(self, switch: str = SWITCH_NAME) -> str:
        """Connect SP6T Com to Port 6."""
        resp = self.send(f"SP6T{switch.upper()}:STATE:6")
        if resp == "1":
            print(f"[SP6T{switch.upper()}] -> Port 6")
        else:
            print(f"[SP6T{switch.upper()}] set Port 6 failed: {resp}")
        return resp

    def disconnect(self, switch: str = SWITCH_NAME) -> str:
        """Disconnect all ports."""
        resp = self.send(f"SP6T{switch.upper()}:STATE:0")
        if resp == "1":
            print(f"[SP6T{switch.upper()}] -> Disconnected")
        return resp

    def get_state(self, switch: str = SWITCH_NAME) -> str:
        """Query current port state (returns '0'..'6')."""
        resp = self.send(f"SP6T{switch.upper()}:STATE?")
        print(f"[SP6T{switch.upper()}] Current state: Port {resp} (0=disconnected)")
        return resp

    def get_counters(self, switch: str = SWITCH_NAME) -> str:
        """Query switch cycle counters for all ports."""
        resp = self.send(f"SP6T{switch.upper()}:COUNTERS?")
        print(f"[SP6T{switch.upper()}] Counters: {resp}")
        return resp


class RFSwitchBoxTelnet:
    """Control RF Switch Box via Telnet (raw TCP socket)."""

    def __init__(self, ip: str = SWITCH_IP, port: int = TELNET_PORT):
        self.ip      = ip
        self.port    = port
        self._socket = None

    def connect(self):
        self._socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self._socket.settimeout(TIMEOUT_SEC)
        self._socket.connect((self.ip, self.port))
        time.sleep(0.2)
        try:
            self._socket.recv(1024)  # discard welcome banner
        except socket.timeout:
            pass

    def close(self):
        if self._socket:
            self._socket.close()
            self._socket = None

    def send(self, command: str) -> str:
        if not self._socket:
            raise RuntimeError("Not connected. Call connect() first.")
        self._socket.sendall((command + "\r\n").encode("ascii"))
        return self._readline()

    def _readline(self) -> str:
        """Read until \\r\\n (or timeout), return stripped response."""
        buf = b""
        try:
            while True:
                ch = self._socket.recv(1)
                if not ch:
                    break
                buf += ch
                if buf.endswith(b"\r\n"):
                    break
        except socket.timeout:
            pass
        return buf.decode("ascii", errors="replace").strip()

    def __enter__(self):
        self.connect()
        return self

    def __exit__(self, *_):
        self.close()

    # ── Convenience wrappers (same interface as HTTP class) ───────────────────

    def get_idn(self)                          -> str: return self.send("MN?")  # *IDN? not supported on all firmware
    def get_model(self)                        -> str: return self.send("MN?")
    def get_serial(self)                       -> str: return self.send("SN?")
    def get_firmware(self)                     -> str: return self.send("FIRMWARE?")

    def set_port1(self, switch=SWITCH_NAME)    -> str:
        resp = self.send(f"SP6T{switch.upper()}:STATE:1")
        print(f"[SP6T{switch.upper()}] -> Port 1, resp={resp}")
        return resp

    def set_port2(self, switch=SWITCH_NAME)    -> str:
        resp = self.send(f"SP6T{switch.upper()}:STATE:2")
        print(f"[SP6T{switch.upper()}] -> Port 2, resp={resp}")
        return resp

    def set_port3(self, switch=SWITCH_NAME)    -> str:
        resp = self.send(f"SP6T{switch.upper()}:STATE:3")
        print(f"[SP6T{switch.upper()}] -> Port 3, resp={resp}")
        return resp

    def set_port6(self, switch=SWITCH_NAME)    -> str:
        resp = self.send(f"SP6T{switch.upper()}:STATE:6")
        print(f"[SP6T{switch.upper()}] -> Port 6, resp={resp}")
        return resp

    def disconnect_all(self, switch=SWITCH_NAME) -> str:
        resp = self.send(f"SP6T{switch.upper()}:STATE:0")
        print(f"[SP6T{switch.upper()}] -> Disconnected, resp={resp}")
        return resp

    def get_state(self, switch=SWITCH_NAME)    -> str:
        resp = self.send(f"SP6T{switch.upper()}:STATE?")
        print(f"[SP6T{switch.upper()}] Current state: Port {resp}")
        return resp

    def get_counters(self, switch=SWITCH_NAME) -> str:
        resp = self.send(f"SP6T{switch.upper()}:COUNTERS?")
        print(f"[SP6T{switch.upper()}] Counters: {resp}")
        return resp


# ─── Demo ─────────────────────────────────────────────────────────────────────

def demo_http():
    print("=" * 50)
    print(f"RF Switch Box SP6T - HTTP Demo  ({SWITCH_IP}:{HTTP_PORT})")
    print("=" * 50)

    sw = RFSwitchBoxHTTP(ip=SWITCH_IP, port=HTTP_PORT)

    print(f"IDN      : {sw.get_idn()}")
    print(f"Model    : {sw.get_model()}")
    print(f"Serial   : {sw.get_serial()}")
    print(f"Firmware : {sw.get_firmware()}")

    print()
    sw.get_state()          # query current state

    print("\n--- Switch to Port 1 ---")
    sw.set_port1()
    time.sleep(0.5)
    sw.get_state()

    print("\n--- Switch to Port 2 ---")
    sw.set_port2()
    time.sleep(0.5)
    sw.get_state()

    print("\n--- Switch to Port 3 ---")
    sw.set_port3()
    time.sleep(0.5)
    sw.get_state()
    input(">>> Switch A 已切到 Port 3，請完成測試後按 ENTER 繼續...")

    print("\n--- Switch to Port 6 ---")
    sw.set_port6()
    time.sleep(0.5)
    sw.get_state()
    input(">>> Switch A 已切到 Port 6，請完成測試後按 ENTER 繼續...")

    print("\n--- Disconnect all ---")
    sw.disconnect()

    print("\n--- Switch counters ---")
    sw.get_counters()


def demo_telnet():
    print("=" * 50)
    print(f"RF Switch Box SP6T - Telnet Demo  ({SWITCH_IP}:{TELNET_PORT})")
    print("=" * 50)

    with RFSwitchBoxTelnet(ip=SWITCH_IP, port=TELNET_PORT) as sw:
        print(f"Model    : {sw.get_model()}")
        print(f"Serial   : {sw.get_serial()}")
        print(f"Firmware : {sw.get_firmware()}")

        print()
        sw.get_state()

        print("\n--- Switch to Port 1 ---")
        sw.set_port1()
        time.sleep(0.5)
        sw.get_state()

        print("\n--- Switch to Port 2 ---")
        sw.set_port2()
        time.sleep(0.5)
        sw.get_state()

        print("\n--- Switch counters ---")
        sw.get_counters()


if __name__ == "__main__":
    USE_TELNET = False

    if USE_TELNET:
        demo_telnet()
    else:
        demo_http()