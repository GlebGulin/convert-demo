import * as axios from "axios";
export let instance = axios.create({
    withCredentials: true,
    baseURL : 'http://localhost:1589/',
    headers: {
        "API-KEY":"12356789"
    }
});
export const GetAllHistory = () => {
    return instance.get(`history`
        , {withCredentials: true}
        )
        .then(response => {
            return response.data
        }
    )
         
}
export const PostNewItem = (model) => {
    
    return instance.post(`newitem`, {model},
        {withCredentials: true})
        .then(response => 
            {
                debugger;
                return response.data;
            }
    )
}