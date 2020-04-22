using SoccerWebApi.Models;

namespace SoccerWebApi.Helpers
{
	public interface IMailHelper
	{
		Response SendMail(string to, string subject, string body);
	}
}
