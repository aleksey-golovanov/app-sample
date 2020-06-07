import axios from "axios";

const axiosInstance = axios.create({
    baseURL: "/api",
    headers: { "Cache-Control": "no-cache, no-store, must-revalidate", "Pragma": "no-cache", "Expires": "-1" }
});

axiosInstance.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    if (!axios.isCancel(error)) {
        //alert.show(`${error.response.data.error} ${error.response.data.id}`, { timeout: 0, type: "error" });
        //TODO: alert
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
