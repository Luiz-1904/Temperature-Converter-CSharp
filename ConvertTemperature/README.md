# Temperature Converter - Console Application

This project is a simple temperature converter built in C#. It allows the user to input a temperature, specify its current scale, and convert it to a desired scale. The program runs entirely in the console and includes input validation to ensure a smooth user experience.

- Converts temperatures between the following scales:
  - Celsius (C)
  - Fahrenheit (F)
  - Kelvin (K)

## How to Use

1. **Enter the Temperature**: Provide a numeric value representing the temperature.
2. **Select the Current Scale**: Choose the current temperature scale by typing `C` (Celsius), `F` (Fahrenheit), or `K` (Kelvin).
3. **Select the Target Scale**: Choose the target scale for conversion by typing `C`, `F`, or `K`.
4. **View the Result**: The program will display the converted temperature.
5. **Continue or Exit**: Choose whether to perform another conversion (`Y`) or exit (`N`).

## Code Structure

1. **Main Method**:

   - Manages the program loop and calls the user interface (`Interface()`).

2. **Interface Method**:

   - Handles user interaction, collects inputs, and calls the conversion logic.

3. **Helper Methods**:
   - `validNumber(string message)`: Ensures the user input is a valid integer.
   - `validTemperature(string message)`: Ensures the user selects a valid temperature scale (`C`, `F`, or `K`).
   - `conversorVerifier(int num, char initialTemp, char finalTemp)`: Converts the temperature based on the selected scales.

## Conversion Logic

The program supports the following conversions:

| **From** | **To**  | **Formula**                     |
| -------- | ------- | ------------------------------- |
| Celsius  | Kelvin  | `num + 273.15`                  |
| Celsius  | Fahren. | `num * (9 / 5) + 32`            |
| Fahren.  | Celsius | `(num - 32) * (5 / 9)`          |
| Fahren.  | Kelvin  | `(num - 32) * (5 / 9) + 273.15` |
| Kelvin   | Celsius | `num - 273.15`                  |
| Kelvin   | Fahren. | `(num - 273.15) * (9 / 5) + 32` |

If the same scale is selected for both input and output, the program simply returns the original value.
