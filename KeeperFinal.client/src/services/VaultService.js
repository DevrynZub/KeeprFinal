import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class VaultService {
  // async getVaultsByAccount(accountId) {
  //   const res = await api.get('account/vaults', accountId)
  //   logger.log(res.data)
  // }

  async getVaultsByProfileId(profileId) {
    // logger.log('[AM I GETTING Vaults?]', profileId)
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log('[AM I GETTING Vaults?]', res.data)
    AppState.vaults = res.data.map(v => new Vault(v))
  }

  async getVaultById(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    logger.log('GOT VAULT', res.data)
    const newVault = new Vault(res.data)
    AppState.activeVault = newVault

  }

  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log('[CREATED VAULT]', res.data)
    const newVault = new Vault(res.data)
    AppState.vaults.push(newVault)
  }

}

export const vaultService = new VaultService()