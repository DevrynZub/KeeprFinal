<template>
  <div class="container-fluid" v-if="activeVault">
    <div class="row mt-2">
      <div class="col-md-6">
        <div class="image-container">
          <img class="img-fluid" :src="activeVault.img" :alt="activeVault.name">
          <h1 class="vault-name">{{ activeVault.name }}</h1>
          <p class="creator-name">{{ activeVault.creator.name }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, watchEffect } from 'vue';
import { vaultService } from '../services/VaultService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { useRoute } from 'vue-router';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';

export default {
  setup() {
    const route = useRoute();

    async function getVaultById() {
      try {
        let vaultId = route.params.vaultId
        await vaultService.getVaultById(vaultId);
      } catch (error) {
        Pop.error(error.message);
      }
    }

    async function getKeepsByVaultId() {
      try {
        await keepsService.getKeepsByVaultId(route.params.vaultId);
      } catch (error) {
        logger.error(error)
      }
    }

    watchEffect(() => {
      route.params.vaultId;
      getVaultById();
      getKeepsByVaultId();
    });

    return {
      activeVault: computed(() => AppState.activeVault),

    };
  },
};
</script>

<style lang="scss" scoped></style>
