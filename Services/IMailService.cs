using System.Threading.Tasks;

namespace olepunchy.Services {
    public interface IMailService {
        Task SendEmailAsync(string fromAddress, string subject, string body);
    }
}