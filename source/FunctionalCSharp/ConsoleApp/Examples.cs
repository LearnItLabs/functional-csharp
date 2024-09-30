using ConsoleApp.FunctionalHelpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp {

	internal class Examples {

		public void RunUnitType() {
			Unit result;
			result = Log.LogMessage("hello");
			result = Log.LogMessage("goodbye");
		}

		public void RunOptionType() {
			// option could contain a valid int
			// or not.
			Option<int> age;
			age = Option<int>.Some(5);
			age = Option<int>.None();

			Option<string> teamName;
			teamName = Option<string>.None();
			teamName = Option<string>.Some("BlueHornets");
		}

		public async Task<Option<string>> FetchApiData(string url) {
			using var httpClient = new HttpClient();
			HttpResponseMessage response = await httpClient.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				return Option<string>.Some(content);
			}

			return Option<string>.None();
		}

		public async void RunApiCall() {
			string url = "https://api.example.com/person-api";
			Option<string> dataOption = await FetchApiData(url);
			string personData = dataOption.Match(
															content => content,
															() => "No data available"
			);

			Console.WriteLine(personData);
		}

		public String CheckUsername(String userName) {
			if (NameAlreadyTaken(userName))
			{
				throw new FormatException("Username is already used");
			}

			if (NameIncorrectLength(userName))
			{
				throw new FormatException("Username must be between 8 and 24 characters");
			}

			if (NameContainsSymbol(userName))
			{
				throw new FormatException("Username cannot contain a symbol");
			}

			return userName;
		}

		public void RunOld() {
			try
			{
				var validUsername = CheckUsername("Sooni-4356");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void RunNew() {

var validUsername = CheckUsernameBetter("Sooni-4356");
string message = string.Empty;
validUsername.Match(
	error => message = $"Error: {error.Message}:Code{error.Code}",  // Handling error
	validUsername => message =($"Valid username: {validUsername}")  // Handling success
	);

Console.WriteLine(message);

		}
			public Either<ErrorInfo, string> CheckUsernameBetter(string userName) {

			if (NameAlreadyTaken(userName))
			{
				var errorInfo = new ErrorInfo(message: "Username is already used", code: 37);
				return Either<ErrorInfo, string>.Left(errorInfo);
			}

			if (NameIncorrectLength(userName))
			{
				var errorInfo = new ErrorInfo(message: "Username between 8 and 24 characters", code: 23);

				return Either<ErrorInfo, string>.Left(errorInfo);
			}

			if (NameContainsSymbol(userName))
			{
				var errorInfo = new ErrorInfo(message: "Username cannot contain a symbol", code: 38);
				return Either<ErrorInfo, string>.Left(errorInfo);
			}

			return Either<ErrorInfo, string>.Right(userName);
		}


		public bool NameAlreadyTaken(string name) {
			return true;
		}

		public bool NameContainsSymbol(string name) {
			return true;
		}

		public bool NameIncorrectLength(string name) {
			return true;
		}
	}

public class ErrorInfo {
	public string Message { get; }
	public int Code { get; }

	public ErrorInfo(string message, int code) {
		Message = message;
		Code = code;
	}
}
}