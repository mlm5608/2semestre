import axios from "axios";

// const apiPort = "7118";
// const localApi = `https://localhost:${apiPort}/api`;
const externalApi = "https://eventapiwebmiguel.azurewebsites.net/api";

const api = axios.create({
    baseURL : externalApi
});


export default api;