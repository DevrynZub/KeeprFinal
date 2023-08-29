import { AppState } from "../AppState.js"
import { Profile } from "../models/Profile.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class ProfileService {

  async getProfileById(profileId) {
    // logger.log('[AM I GETTING THIS?]', profileId)
    const res = await api.get(`api/profiles/${profileId}`)
    logger.log('[GETTING PROFILE Id]', res.data)
    const newProfile = new Profile(res.data)
    AppState.profiles.push(newProfile)
  }

}
export const profileService = new ProfileService()