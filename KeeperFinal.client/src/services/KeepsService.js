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

  async setActiveKeep(keep) {
    await api.get(`api/keeps/${keep.id}`)
    AppState.activeKeep = keep
    AppState.activeKeep.views++
    logger.log("This is my active keep", AppState.activeKeep)
  }

  // FIXME pass profileId as param here
  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log('[CREATED KEEP]', res.data)
    const newKeep = new Keep(res.data)
    // FIXME check to see if the profileId matches the person logged in, if it does push it, if not don't
    AppState.keeps.push(newKeep)
  }

  async getKeepsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    // logger.log('[AM I GETTING KEEPS?]', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async removeKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    logger.log('You deleted a keep', res.data)
    const keepIndex = AppState.keeps.findIndex(keep => keep.id == keepId)
    AppState.keeps.splice(keepIndex, 1)
    AppState.activeKeep = ''
  }

  async addKeepToVault(vaultKeepId) {
    const res = await api.post(`api/vaultkeeps`, vaultKeepId)
    AppState.activeKeep.kept++
    logger.log('[Added keep to vault]', res.data)
  }

}

export const keepsService = new KeepsService()