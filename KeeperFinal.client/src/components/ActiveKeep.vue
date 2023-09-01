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
                <button @click="removeVaultKeep(vaultKeepId)">Remove VaultKeep</button>
                <div class="dropdown">
                  <button class="btn btn-secondary-outline dropdown-toggle fs-3 mb-4" type="button"
                    data-bs-toggle="dropdown" aria-expanded="false">
                    Vaults
                  </button>
                  <ul class="dropdown-menu">
                    <!-- FIXME v-for over myVaults to draw li  -->
                    <!-- FIXME how can I pass the vault id here? -->
                    <li v-for="vault in myVaults" :key="vault.id">
                      <a class="dropdown-item" href="#" @click="addKeepToVault(vault.id)">{{ vault.name }}</a>
                    </li>
                  </ul>
                </div>
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

import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';
import { vaultService } from '../services/VaultService.js';
import { logger } from '../utils/Logger.js';




export default {
  props: {
    keepProp: { type: Keep, require: true }
  },
  setup() {


    return {
      keep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults),
      vaultKeep: computed(() => AppState.vaultKeep),


      async addKeepToVault(vaultId) {
        try {
          await keepsService.addKeepToVault(AppState.activeKeep.id, vaultId)
        } catch (error) {
          Pop.error(error.message)
        }
      },

      async removeVaultKeep(vaultKeepId) {
        try {
          const confirmDelete = await Pop.confirm('Remove keep from vault?');
          if (confirmDelete) {
            await vaultService.removeVaultKeep(vaultKeepId);
          }
        } catch (error) {
          Pop.error(error.message);
          logger.log(error);
        }
      }








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