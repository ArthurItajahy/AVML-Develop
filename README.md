# Avium Language (.avml)

Welcome to the official repository for **Avium Language (.avml)**, a programming language designed to automate and optimize interstellar missions in **Kerbal Space Program (KSP) 1.12.1**. Inspired by tools like kOS, Avium Language offers a robust scripting environment for controlling spacecraft with precision and efficiency.

---

## What is Avium Language?

Avium Language is a lightweight yet powerful scripting language tailored for:

- Automating spacecraft maneuvers.
- Writing efficient and reusable scripts for interstellar missions.
- Managing complex mission profiles with ease.

With Avium Language, you can:
- Calculate delta-v requirements.
- Execute orbital transfers and gravity assists.
- Automate staging, burns, and docking procedures.
- Create robust mission logic for interplanetary exploration.

---

## Features

- **KSP Integration**: Specifically designed for KSP 1.12.1, ensuring seamless interaction with the game.
- **Lightweight Syntax**: Focus on writing clean and readable code.
- **Advanced Automation**: Handle everything from basic burns to multi-stage missions with complex dependencies.
- **Mod-Friendly**: Compatible with mods like Realism Overhaul and RSS.

---

## Example Script

Here’s a simple example of an Avium script to perform a prograde burn:

```avml
// Set up autopilot
activate autopilot;
set direction to prograde;

// Burn parameters
set targetDeltaV to 1000; // Delta-v in m/s
while remainingDeltaV > 0 {
    throttle to 1.0;
}
throttle to 0.0;
deactivate autopilot;
```

---
## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

---

Happy coding, and may your journeys through the cosmos be smooth and successful! 🚀
