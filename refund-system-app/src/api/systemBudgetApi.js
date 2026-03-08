import apiClient from "./apiClient";

export const getSystemBudget = async () => {
  const response = await apiClient.get("/SystemBudget");
  return response.data;
};