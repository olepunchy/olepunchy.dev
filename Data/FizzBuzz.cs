using System.Collections.Generic;
using System.Threading.Tasks;

namespace olepunchy.Data {

    public class FizzBuzz {

        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public List<(string, string)> Results { get; set; } = new();

        public Task CalculateFizzBuzz(FizzBuzz fizzBuzz) {

            for (int index = fizzBuzz.StartValue; index <= fizzBuzz.EndValue; index++) {

                if (index % 3 == 0 && index % 5 == 0) {
                    // NOTE:
                    // index divided by 3 and 5 has a remainder of 0
                    fizzBuzz.Results.Add((index.ToString(), "FizzBuzz"));
                    continue;
                }

                if (index % 3 == 0) {
                    // NOTE:
                    // index divided by 5 has a remainder of 0
                    fizzBuzz.Results.Add((index.ToString(), "Fizz"));
                    continue;
                }

                if (index % 5 == 0) {
                    // NOTE:
                    // index divided by 3 has a remainder of 0
                    fizzBuzz.Results.Add((index.ToString(), "Buzz"));
                    continue;
                }

                fizzBuzz.Results.Add((index.ToString(), ""));
            }

            return Task.CompletedTask;
        }
    }
}
