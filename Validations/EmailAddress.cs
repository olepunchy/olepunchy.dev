using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace olepunchy.Validations {
    public class EmailAddress : ValidationAttribute {
        public override bool IsValid(object value) {
            var input = value as string;

            if (string.IsNullOrEmpty(input)) {
                return false;
            }

            return EmailIsValid(input);
        }

        private bool EmailIsValid(string input) {
            if (string.IsNullOrWhiteSpace(input)) {
                return false;
            }

            try {
                input = Regex.Replace(input, @"(@)(.+)$", DomainMapper, RegexOptions.None,
                    TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match) {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            } catch (RegexMatchTimeoutException) {
                return false;
            } catch (ArgumentException) {
                return false;
            }

            try {
                return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250));
            } catch (RegexMatchTimeoutException) {
                return false;
            }
        }
    }
 }