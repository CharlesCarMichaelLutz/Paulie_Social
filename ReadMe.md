# Paulie Social

A Single Page Application built with a React JS frontend, and C# web api server that queries the X (formerly Twitter) API for data.

#### check it out [here](https://pauliesocialwebapi20240511111452.azurewebsites.net/)


----------

![readme paulie](https://github.com/Charles-CarM/Paulie_Social/assets/103493003/7fd62e6c-4117-4962-868c-bdf59197f76d)


## Summary

I had a blast building my initial full-stack application with a React frontend, and C# server, which queries the X API as the data access layer. Getting all three areas of the application working together as expected was a good challenge. Requesting data for tweets is broken apart into
different data structures that need to be called with separate methods. On the backend I applied the Inversion Of Control principle using the AddScoped method to register services with the Dependency Injection container. This process allowed the data flow to be visualized clearly. It was awesome working with the external Twitter API and creating Paulie Social. 
## Installation

1. Clone the repository above

2. Go [here]( https://developer.twitter.com/en/docs/twitter-api/getting-started/getting-access-to-the-twitter-api ) and apply for an X API Key

3. In Solution go to PaulieSocialWebAPI and right click

4. Select Manage User Secrets

5. Add the following to secrets.json file:
        "Twitter:bearerToken": "PASTE API KEY HERE"

### Author
* __Charles Lutz__ - *Full-Stack Software Developer* - [Personal Website](https://charlescarmichaellutz.github.io/) | [LinkedIn](https://www.linkedin.com/in/CharlesCarMichaelLutz)
