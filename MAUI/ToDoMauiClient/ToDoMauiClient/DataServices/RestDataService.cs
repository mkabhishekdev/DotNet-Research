using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoMauiClient.Models;

namespace ToDoMauiClient.DataServices
{
	public class RestDataService : IRestDataService
	{

		private readonly HttpClient _httpClient;
		private readonly string _baseAddress;
		private string _url;
		private readonly JsonSerializerOptions _jsonSerializerOptions;

		public RestDataService(HttpClient httpClient)
        {
			//   _httpClient = new HttpClient();  use httpclient factory: because client factory manages connection threads etc. you do not end up in connection exhaustion
			_httpClient = httpClient;

			//The below base address needs to be set to the port in which your ToDoAPI project is running
			_baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5209" : "https://localhost:7280";
			_url = $"{_baseAddress}/api";

			_jsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
        }

        public async Task AddToDoAsync(ToDo toDo)
		{
			if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
			{
				Debug.WriteLine("---> No internet");
				return;
			}
			try
			{
				string jsonToDo = JsonSerializer.Serialize<ToDo>(toDo,_jsonSerializerOptions);
				StringContent content = new StringContent(jsonToDo,Encoding.UTF8,"application/json");

				HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/todo",content);

				if(response.IsSuccessStatusCode)
				{
					Debug.WriteLine("Successfully created ToDo");
				}
				else
				{
					Debug.WriteLine("-->non http response");
				}
			}
			catch (Exception ex) 
			{
				Debug.WriteLine($"exception: {ex.Message}");
			}
			return;
		}

		public async Task DeleteToDoAsync(int id)
		{
			if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
			{
				Debug.WriteLine("---> No internet");
				return;
			}
			try
			{
				HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/todo/{id}");

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine("Successfully created ToDo");
				}
				else
				{
					Debug.WriteLine("-->non http response");
				}
			}
			catch(Exception ex) 
			{
				Debug.WriteLine($"exception: {ex.Message}");
			}
			return;
		}

		public async Task<List<ToDo>> GetAllToDosAsync()
		{
			List<ToDo> todos = new List<ToDo>();

			if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
			{
				Debug.WriteLine("---> No internet");
				return todos;
			}

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");

				if(response.IsSuccessStatusCode)
				{
				    string content = await response.Content.ReadAsStringAsync();
					todos = JsonSerializer.Deserialize<List<ToDo>>(content,_jsonSerializerOptions); // json to list object
				}
				else
				{
					Debug.WriteLine("---> non http response");
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine($"exception: {ex.Message}");
			}
			return todos;
		}

		public async Task UpdateToDoAsync(ToDo toDo)
		{
			if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
			{
				Debug.WriteLine("---> No internet");
				return;
			}
			try
			{
				string jsonToDo = JsonSerializer.Serialize<ToDo>(toDo, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");

				HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/todo/{toDo.Id}", content);

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine("Successfully created ToDo");
				}
				else
				{
					Debug.WriteLine("-->non http response");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"exception: {ex.Message}");
			}
			return;
		}
	}
}
