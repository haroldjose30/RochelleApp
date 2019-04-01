class GenericRepository {

    constructor(resource, urlBase = '/api/') {
        this._urlBase = urlBase
        this._resource = resource
        this._urlResource = urlBase + resource
    };


    get = async () => {
        return fetch(this._urlResource)
            .then(response => response.json())
            .then(data => {
                console.log('data is', data);
                return data;
            })
            .catch(error => console.log('error is', error));

    };


    getById = async (id) => {

    };


    post = async (model) => {

        let resStatus = 0;
        return fetch(this._urlResource, {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json;charset=utf-8',
            },
            body: JSON.stringify(model)
        })
            .then(res => {
                resStatus = res.status
                switch (resStatus) {
                    case 500:
                    console.log('error500:',res);
                        return res;
                        break
                    default:
                        return res.json();
                        break
                }
            })
            .then(data => {
                switch (resStatus) {
                    case 200:
                        return data;
                        break
                    case 400:
                        throw Error(data.errors);
                        break
                    case 500:
                        console.log('error500:',data);
                        throw Error(`Erro ao tentar acessar ${this._urlResource}. Status:${data.statusText}`);
                        break
                    default:
                        throw Error(`Erro ao tentar acessar ${this._urlResource}. unhandled`);
                        break
                }
            })
    };

    put = async (model) => {

        console.log('json:', JSON.stringify(model));
       
        let resStatus = 0;
        return fetch(this._urlResource, {
            method: 'PUT',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json;charset=utf-8',
            },
            body: JSON.stringify(model)
        })
            .then(res => {
                resStatus = res.status
                switch (resStatus) {
                    case 500:
                    console.log('error500:',res.json());
                        return res;
                        break
                    default:
                        return res.json();
                        break
                }
            })
            .then(data => {
                switch (resStatus) {
                    case 200:
                        return data;
                        break
                    case 400:
                        throw Error(data.errors);
                        break
                    case 500:
                    console.log('error500:',data);
                        throw Error(`Erro ao tentar acessar ${this._urlResource}. Status:${data.statusText}`);
                        break
                    default:
                        throw Error(`Erro ao tentar acessar ${this._urlResource}. unhandled`);
                        break
                }
            })
    };

    delete = function (model) {


    };


};

export default GenericRepository;