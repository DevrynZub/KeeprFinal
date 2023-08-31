<template>
  <div class="container-fluid" v-if="keep">
    <div class="row">
      <div class="col-md-6 col-12 d-flex ps-0">
        <img class="img-fluid rounded-start keep-image" :src="keep.img" alt="KEEP">
      </div>
      <div class="col-md-6 col-12 d-flex align-items-center">
        <div class="row">
          <div class="col-12 fs-3">
            <div class="d-flex justify-content-evenly mb-3">
              <p class="mdi mdi-eye-outline">{{ keep.views }}</p>
              <p class="mdi mdi-safe">{{ keep.kept }}</p>
            </div>

            <div class="text-center">
              <p class="keep-name">{{ keep.name }}</p>
              <p class="description rounded px-1">{{ keep.description }}</p>
            </div>
          </div>

          <div class="row">
            <div class="col-12 mt-5">
              <div class="dropdown">
                <button class="btn btn-secondary-outline dropdown-toggle fs-3 mb-4" type="button"
                  data-bs-toggle="dropdown" aria-expanded="false">
                  Vaults
                </button>
                <ul class="dropdown-menu">
                  <li><button class="dropdown-item" type="button" @click="addKeepToVault(vaults[1].id)">{{ vaults[1]?.name
                  }}</button></li>
                  <li><button class="dropdown-item" type="button" @click="addKeepToVault(vaults[2].id)">{{ vaults[2]?.name
                  }}</button></li>
                </ul>
              </div>
              <router-link :to="{ name: 'Profile', params: { profileId: keep.creator.id } }">
                <img :src="keep.creator.picture" class="keep-profile">
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { Keep } from '../models/Keep.js';
import { logger } from '../utils/Logger.js';
import { vaultService } from '../services/VaultService.js';




export default {
  props: {
    keepProp: { type: Keep, require: true }
  },
  setup() {

    async function getVaultsByAccount() {
      try {
        await vaultService.getVaultsByAccount()
      } catch (error) {
        logger.error(error)
      }
    }

    onMounted(() => {
      getVaultsByAccount();
    })


    return {
      keep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
    }
  },
}







</script>


<style lang="scss" scoped>
.keep-image {
  width: 100%;
  object-fit: cover;
}

.keep-name {
  font-size: 1.5rem;
  font-weight: bold;
  margin-bottom: 10px;
}

.keep-profile {
  height: 7vh;
  width: 7vh;
  justify-content: end;
  border-radius: 70%;
  position: absolute;
  bottom: 8px;
  right: 16px;
  font-size: 18px;
}
</style>