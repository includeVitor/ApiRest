import axios from "axios"

const api = axios.create({
    baseURL: 'https://testsmart.azurewebsites.net/api/v1',    
})

export default api