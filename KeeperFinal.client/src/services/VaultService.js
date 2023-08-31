import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class VaultService {
  async getVaultsByProfileId(profileId) {
    // logger.log('[AM I GETTING Vaults?]', profileId)
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log('[AM I GETTING Vaults?]', res.data)
    AppState.vaults = res.data.map(v => new Vault(v))
  }

  async getKeepsByVaultId(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('SHOW ME THE MAGIC CONSOLE of KEEPS?', res.data)
    const newKeeps = res.data.map(keepPojo => new Keep(keepPojo))
    AppState.keeps = newKeeps
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

  async removeVault(vaultId) {
    const res = await api.delete(`api/vaults/${vaultId}`)
    logger.log('[You deleted a Vault ${vaultId}]', res.data)
    const vaultIndex = AppState.vaults.findIndex(vault => vault.id == vaultId)
    AppState.vaults.splice(vaultIndex, 1)
  }

  async GetVaultsByAccount(accountId) {
    const res = await api.get('accounts/vaults', accountId)
    logger.log('Getting my account vaults', res.data)
  }

}

export const vaultService = new VaultService()