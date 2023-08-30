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

  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log('[CREATED KEEP]', res.data)
    const newKeep = new Keep(res.data)
    AppState.keeps.push(newKeep)
  }

  async getKeepsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log('[AM I GETTING KEEPS?]', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async getKeepsByVaultId(vaultId) {
    logger.log('SHOW ME THE MAGIC CONSOLE?')
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('SHOW ME THE MAGIC CONSOLE of KEEPS?', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }


}

export const keepsService = new KeepsService()