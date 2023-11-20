# Address Standardization Web Service

This project is a web service developed in ASP.NET Core/C# that performs address standardization using the Dadata service.

## Prerequisites

- Dadata API key (sign up [here](https://dadata.ru/) to get your API key)

## Getting Started

1. Clone this repository.
2. Configure the Dadata API key in `env.api` file.
3. Build and run the project.

## Usage

Make a GET request to the API endpoint with a following JSON:
```
{
    "rawaddress": "some address"
}
```


Receive the standardized address model in JSON format.