# ChallengesChallenges

## Postman collection

The postman collection is included in the repo ready to be imported and tested, is at the following location: **ChallengesChallenges/Challenges/API/PostmanCollection/**

## API Urls to enter in the Test App:

- Exercise 1: https://sri20210523175813.azurewebsites.net/api
- Exercise 2: https://sri20210523175813.azurewebsites.net/api/Product
- Exercise 3: https://sri20210523175813.azurewebsites.net/api

## Project structure:

This solution contains two cs projects, the App project (Challenges) and the tests project (Challenges.Tests)

## Misc Notes

- All exercises passed.
- All unit tests written with NUnit and Moq.
- Validations and logs where necessary.
- Used factory pattern for exercise2 (sorting products)

Hosted on Azure. Complete Urls as follows:

- BaseUrl: https://sri20210523175813.azurewebsites.net/api
- GetUser: GET https://sri20210523175813.azurewebsites.net/api/user
- GetSortedProducts:
  - Low: GET https://sri20210523175813.azurewebsites.net/api/Product/sort?sortOption=Low
  - High: GET https://sri20210523175813.azurewebsites.net/api/Product/sort?sortOption=High
  - Ascending: GET https://sri20210523175813.azurewebsites.net/api/Product/sort?sortOption=Ascending
  - Descending: GET https://sri20210523175813.azurewebsites.net/api/Product/sort?sortOption=Descending
  - Recommended: GET https://sri20210523175813.azurewebsites.net/api/Product/sort?sortOption=Recommended
- TrolleyTotal: POST https://sri20210523175813.azurewebsites.net/api/trolleyTotal
- Additional TrolleyTotal that simulates the resource API. Tested it works with one special.
  - POST https://sri20210523175813.azurewebsites.net/api/trolleyTotal/Custom

## Technologies

- ASP.Net core WebAPI
- Visual Studio 2019.

## 3rd party packages

- NUnit (3.12)
- Moq (4.13.1)
