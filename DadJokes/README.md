To use: 
run
```
dotnet run
```

This is an application that prompts the user to enter a topic and then retrieves a dad joke related to that topic from the icanhazdadjoke API. The application uses the System.Net.Http namespace to send an HTTP GET request to the API, and then reads the response data as a string. If the response indicates success, the application deserializes the JSON data into a custom DadJokeResponse object using the Newtonsoft.Json library, and then selects a random joke from the list of results, and prints it to the console. If there are no jokes related to the topic, the application outputs a message indicating this.

To expand the code i could also add a loop to allow the user to request multiple jokes without having to restart the application. Additionally, I could modify the output formatting or incorporate other APIs or data sources to provide more diverse or interesting jokes.
