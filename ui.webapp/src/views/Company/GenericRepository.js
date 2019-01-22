//var postRequest = new Request(urlResource, options('POST'));
//var putRequest = new Request(urlResource, options('PUT'));
//var deleteRequest = new Request(urlResource, options('DELETE'));

class GenericRepository {
   
    constructor(resource,urlBase='/api/') {
        this._urlBase = urlBase
        this._resource = resource
        this._urlResource = urlBase+resource
    };

     _defaultHeaders = new Headers({
        "Content-Type": "application/json; charset=utf-8",
     });


    _options = method => {
        return {method: method,
                headers: this._defaultHeaders,
                mode: 'cors'}
    }


    get = async () => {
        const getRequest = new Request(this._urlResource,this._options('GET'));
        const response = await this._callApi(getRequest)
        return response
    };


    getById = async (id) => {
        const getRequest = new Request(`${this._urlResource}/${id}`,this._options('GET'));
        const response = await this._callApi(getRequest)
        return response
    }



     post = function(company, callback) {
       /*
        fetch(urlResource, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: JSON.stringify(company)
        })
        */

    };

     put = function(company, callback) {
        /*
        fetch(urlResource, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'PUT',
            body: JSON.stringify(company)
        })
        */
    };

     delete = function(company, callback) {

       /*
        fetch(urlResource, { 
            method: 'DELETE' 
        });
        */ 

    };


     _callApi = async (getRequest) => {
        const response = await fetch(getRequest);
        var body = {}
    
        try {
          
             if (response.status >= 200 && response.status <= 299) {
                body = await response.json();
                //console.log('body=200');
                //console.log(body);
                return body
             }
            else{
                    body = await response.json();
                    //console.log('body<>200');
                    //console.log(body);
                    var message = ''
                    if (body.notifications === undefined)
                        message = `Erro desconhecido ao tentar acessar ${this._urlResource}. Status:${response.statusText}`
                    else {
                        body.notifications.forEach(erro => {
                            message += erro+'\n'
                        });
                    }
                      
                    //console.log('message');
                    //console.log(message);
                    throw Error(message);
            }
            
             
        } catch (error) {
            if (error.message !== 'JSON.parse: unexpected end of data at line 1 column 1 of the JSON data') 
                throw Error(error.message);
            else
                throw Error(`Erro ao tentar acessar ${this._urlResource}. Status:${response.statusText}`);
        }
      
    };


};
 
 export default GenericRepository;