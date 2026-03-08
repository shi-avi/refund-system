import apiClient from "./apiClient";

export const getIncomeByCitizenByYear = async (citizenId) => {
  const response = await apiClient.get(`/Income/citizen/${citizenId}/by-year`);
  return response.data;
};