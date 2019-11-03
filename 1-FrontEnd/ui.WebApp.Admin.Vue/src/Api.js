export default class Api {
  constructor(url) {
    this.url = url;
    this.token = null;

    this.errorHandlers = {
      401: null,
      404: null,
      500: null,
      502: null
    };
  }

  setToken(token) {
    this.token = token;
  }

  setErrorHandler(handler, statusCode) {
    this.errorHandlers[statusCode] = handler;
  }

  _fetchApi(options) {
    console.log("options",options);
    
    let urlResource = this.url +"/"+ options.module;
    if (options.method === "get" || options.method=== "delete" ) {
      if (options.parameters) {
        const urlParams = new URLSearchParams(Object.entries(options.parameters));
        urlResource = urlResource+"?"+urlParams
      }
    }
      

    console.log(urlResource);

    var myHeaders = new Headers();
    myHeaders.append("Accept", "application/json");
    myHeaders.append("Content-Type", "application/json");

    if (this.token)
      myHeaders.append("Authorization", `Bearer ${this.token}`);


    console.log("token",this.token);
    

    var myInit = {
      method: options.method,
      headers: myHeaders,
      mode: "cors",
      cache: "default",
      body: JSON.stringify(options.body)
    };

    fetch(urlResource, myInit)
    .then(function(response) {
      if (response.status === 400) {
        response.json().then(function(result) {
          console.log("result",result);
          options.error(result.errors, response.status);
        });
      } else if (response.status === 200) {
        response.json().then(function(result) {
          console.log("result",result);
          options.success(result)
        });
      }
    })
      .catch(err => {
        console.log("erro", err);

        let response = err.response || {};
        let json = response.body;

        if (this.errorHandlers[err.status])
          this.errorHandlers[err.status](json);

        options.error(json, err.response.status);
      });
  }

  call(options) {
    if (!options.success) {
      options.success = () => {};
    }

    if (!options.error) {
      options.error = () => {};
    }

    this._fetchApi(options);
  }
}
