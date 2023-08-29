import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class VaultService {

  async getVaults() {
    const res = await api.get('api/vaults')
    logger.log(res.data)
  }






  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log('[CREATED VAULT]', res.data)
  }

}

export const vaultService = new VaultService()