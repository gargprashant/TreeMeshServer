# IMP : Check https://github.com/gargprashant/TreeMeshClient.git for client implementation.

# Relay Diagnostics Toolkit

A modular, diagnostic-first framework for simulating and validating media relay topologies using WebRTC, SignalR, and encoded frame pipelines.

> Built with deep architectural clarity and diagnostic precision — in collaboration with Microsoft Copilot 🤝

---

## 🧠 Project Overview

This toolkit enables developers to:
- Simulate tree and mesh topologies for media relays
- Validate stream decoupling and delay injection
- Relay encoded frames via DataChannel
- Visualize and debug signaling flows with modular hooks

It is designed for reproducibility, extensibility, and future dashboard integration.

---

## 🧩 Architecture

### Client Modules (`ClientApp/dist/js`)
- `CanvasWritableStream.js`: Renders encoded frames to canvas
- `DataChannelWrapper.js`: Abstracts transport layer
- `DOMHelper.js`: Manages UI scaffolding
- `EncodedFrameGenerator.js`: Synthesizes test frames
- `RTCChildNode.js`: Handles peer logic
- `SignalingManager.js`: Orchestrates signaling
- `TreeBuilderClient.js`: Constructs client-side topology

### Server Components (`Server`)
- `SignalRChildNode.cs`: Manages per-peer SignalR connections
- `TreeBuilder.cs`: Builds and validates server-side topology
- `TreeHub.cs`: Central SignalR hub for signaling and diagnostics

---

## 🚀 Getting Started

### Prerequisites
- Node.js (for client)
- .NET SDK (for server)

### Run Client
```bash
cd ClientApp
npm install
# Serve index.html or layout.html with a static server