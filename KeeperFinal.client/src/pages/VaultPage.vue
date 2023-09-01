<template>
  <div class="container-fluid" v-if="activeVault">
    <div class="row mt-2">
      <div class="col-12">
        <div class="image-container text-center">
          <img class="img-fluid" :src="activeVault.img" :alt="activeVault.name">
          <h1 class="vault-name">{{ activeVault.name }}</h1>
          <div v-if="activeVault.creator.id === account.id">
            <i @click.stop="removeVault(activeVault)" class="mdi mdi-delete-circle add-button me-2" title="DELETE"></i>
          </div>
          <p>Keeps: {{ keeps.length }}</p>
        </div>
      </div>
    </div>
    <div class="row text-center">
      <h1>Keeps</h1>
      <div class="col-md-4 col-12 mb-3" v-for="keep in keeps" :key="keep.id">
        <KeepCard :keepProp="keep" />
      </div>
    </div>
    <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.vaultKeepId">
      <button @click="removeVaultKeep(vaultKeep.vaultKeepId)">Remove</button>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { vaultService } from '../services/VaultService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { useRoute, useRouter } from 'vue-router';
import { logger } from '../utils/Logger.js';
import KeepCard from '../components/KeepCard.vue';


export default {
  setup() {
    const route = useRoute();
    const router = useRouter();



    async function getVaultById() {
      try {
        let vaultId = route.params.vaultId;
        await vaultService.getVaultById(vaultId);
      }
      catch (error) {
        Pop.error(error.message);
        logger.log(error);
        if (error.response.data.includes('😂')) {
          router.push({ name: "Home" });
        }
      }
    }
    async function getKeepsByVaultId() {
      try {
        let vaultId = route.params.vaultId;
        await vaultService.getKeepsByVaultId(vaultId);
      }
      catch (error) {
        logger.error(error);
      }
    }
    onMounted(() => {
      route.params.vaultId;
      getVaultById();
      getKeepsByVaultId();
    });
    return {
      account: computed(() => AppState.account),
      activeVault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),

      async removeVault(vault) {
        try {
          const confirmDelete = await Pop.confirm('Delete This Vault?');
          if (confirmDelete) {
            await vaultService.removeVault(vault.id);
            router.push({ name: 'Home' });
          }
          // FIXME add router push
        } catch (error) {
          Pop.error(error.message);
          logger.log(error);
        }
      },

      async removeVaultKeep(vaultKeepId) {
        try {
          const confirmDelete = await Pop.confirm('Remove keep from vault?');
          if (confirmDelete) {
            await vaultService.removeVaultKeep(vaultKeepId);
            const index = AppState.activeVault.vaultKeeps.findIndex(vk => vk.id === vaultKeepId);
            if (index !== -1) {
              AppState.activeVault.vaultKeeps.splice(index, 1);
            }
          }
        } catch (error) {
          Pop.error(error.message);
          logger.log(error);
        }
      }


    };
  },
  components: { KeepCard }
};
</script>

<style lang="scss" scoped></style>
