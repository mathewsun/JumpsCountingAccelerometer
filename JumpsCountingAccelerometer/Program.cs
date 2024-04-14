using Newtonsoft.Json.Linq;

var json = await File.ReadAllTextAsync("jump.json");
var jObject = JObject.Parse(json);

var accelerationData = jObject["acceleration_data"];
var zValues = accelerationData.Select(x => x["acc_z"].Value<double>()).ToArray();

Console.WriteLine(CalculateJumps(zValues, 40));

static int CalculateJumps(double[] values, int windowSize)
{
    var index = 0;
    var jumpCount = 0;

    while (index < values.Length - 1)
    {
        if (values[index] < -8)
        {
            jumpCount++;

            index += windowSize;
        }
        else { index++; }
    }

    return jumpCount;
}
