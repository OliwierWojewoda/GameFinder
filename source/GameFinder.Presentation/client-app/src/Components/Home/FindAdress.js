export async function FindAddress(courtIdToFind) {
    const result = await api.get("/GetAddress"
      , { params: { courtId: courtIdToFind } });
    return result.data
  }