import apiClient from "./apiClient";

export const getCitizenById = async (id) => {
  const response = await apiClient.get(`/Citizen/${id}`);
  return response.data;
};

export const getCitizenByIdentity = async (identity) => {
  const response = await apiClient.get(`/Citizen/identity/${identity}`);
  return response.data;
};

export const createCitizen = async (citizen) => {
  const response = await apiClient.post("/Citizen", citizen);
  return response.data;
};