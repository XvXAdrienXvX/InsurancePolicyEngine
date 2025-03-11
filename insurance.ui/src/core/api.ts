import axios, { AxiosError } from "axios";
import { ApiErrorMessages } from "./interfaces/response";

export const api = axios.create({
  baseURL: "https://localhost:7163/api",
  headers: {
    "Content-Type": "application/json",
  },
  timeout: 10000,
});

api.interceptors.response.use(
  (response) => {
    if (!response.data.isSuccess) {
      return Promise.reject({
        isSuccess: false,
        error: response.data.error || { message: ApiErrorMessages.noDataFound },
      });
    }
    return response;
  },
  (error: AxiosError) => {
    return Promise.reject({
      isSuccess: false,
      error: { message: error.message },
    });
  }
);
