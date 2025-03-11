import { api } from "../api";


export const fetchPolicyTypes = async () => {
    const response = await api.get("Policy/PolicyTypes");
    return response.data;
};
  