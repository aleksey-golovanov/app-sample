import axios from "axios";
import { store } from "./store/store";
import actions from "./store/actions";

const axiosInstance = axios.create({
    baseURL: "/api",
    headers: { "Cache-Control": "no-cache, no-store, must-revalidate", "Pragma": "no-cache", "Expires": "-1" }
});

axiosInstance.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    if (!axios.isCancel(error)) {
        store.dispatch(actions.SET_ERROR_ALERT, `${error.response.data.error} ${error.response.data.id}`);
    }

    return Promise.reject(error);
});

const getOrders = () => {
    return axiosInstance.get("/orders");
}

const getCompanies = () => {
    return axiosInstance.get("/companies");
}

const getPaymentTypes = () => {
    return axiosInstance.get("/paymentTypes");
}

const postOrder = order => {
    return axiosInstance.post("/orders", order);
}

export default { getOrders, getCompanies, getPaymentTypes, postOrder };
