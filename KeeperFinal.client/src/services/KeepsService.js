import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class KeepsService {

  async getKeeps() {
    const res = await api.get('api/keeps')
    logger.log(res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  setActiveKeep(keep) {
    AppState.activeKeep = keep
    logger.log("This is my active keep", AppState.activeKeep)
  }


}

export const keepsService = new KeepsService()