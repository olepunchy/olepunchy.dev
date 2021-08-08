using System.Collections.Generic;

namespace olepunchy.Data {

    public class FizzBuzz {

        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public List<(string, string)> Results { get; set; } = new();
    }
}
