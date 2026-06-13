# HotelCheck UI Design Contract

## Framework Choice
- Use HTML, CSS, and Vanilla JavaScript for the web interface.
- Do not introduce React, Tailwind, or other frontend frameworks.
- The UI must connect to the reservation validation logic implemented in web/app.js.

## Color Palette
- Primary: `#2563EB`
- Secondary: `#14B8A6`
- Background: `#F8FAFC`
- Surface/Card: `#FFFFFF`
- Text Primary: `#0F172A`
- Text Secondary: `#475569`
- Border: `#E2E8F0`
- Success: `#16A34A`
- Error: `#DC2626`

## Typography & Spacing
- Use Segoe UI as the default font.
- Page title: 28px, bold
- Section heading: 20px, semi-bold
- Body text: 14px
- Small helper text: 12px
- Outer page padding: 24px
- Card padding: 24px
- Vertical spacing between form rows: 12px
- Buttons should have at least 42px height.

## Component Rules
- Buttons must always have rounded corners.
- Never place two primary buttons next to each other.
- Labels should always appear above inputs.
- Inputs should have clear borders and enough inner padding.
- Result messages must be shown inside a dedicated result panel.
- Use one primary action button for validation.
- Do not duplicate backend validation rules in the UI more than necessary.
- The UI should collect input, trigger the validation flow, and display the returned result.

## Accessibility Rules
- Maintain strong contrast between text and background.
- Error messages must be clearly visible and readable.
- Do not rely on color alone; also show text status.
