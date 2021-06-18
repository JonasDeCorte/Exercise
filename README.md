# Exercise
Create a NET 5 Web API project with two endpoints (POST) that accept some line properties (see file
‘input.json’). Using these properties, coordinates for every point have to be calculated. All points are
calculated using the Angle.Value and the Line.Length properties and start in origin (0,0). One endpoint
returns all of the results, the other one returns all the results with calculated Value > 10.

- For each calculated point, a Value is calculated by dividing the weight by the cost, and then
multiplied by the length;
- The Line.Number variable starts at 0, this does not have to be validated
- All input must be validated not to be null
-The Line.Cost variable must be between 1-100.
- The Figure.Name variable can be null
- LineNumbers have to be checked to be unique
- If a calculated Value is > 2000, stop the calculation and return a custom Exception with a
message containing the calculated value.
The input is based on this image, the result is the coordinates and a Value

