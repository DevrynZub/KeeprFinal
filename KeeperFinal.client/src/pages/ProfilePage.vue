<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>{{ profile }}</h1>
      </div>
    </div>
    <div class="row">
      <h1>Vaults</h1>
      <div class="col-md-4 col-12 mb-3" v-for="vault in vaults" :key="vault.id">
        <VaultCard :vaultProp="vault" />
      </div>
    </div>
    <div class="row">
      <h1>Keeps</h1>
      <div class="col-md-4 col-12 mb-3" v-for="keep in keeps" :key="keep.id">
        <KeepCard :keepProp="keep" />
      </div>
    </div>
  </div>
</template>


<script>
import { computed, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import { profileService } from '../services/ProfileService.js';
import { useRoute } from 'vue-router';
import { vaultService } from '../services/VaultService.js';
import Pop from '../utils/Pop.js';
import VaultCard from '../components/VaultCard.vue';
import { keepsService } from '../services/KeepsService.js';
import KeepCard from '../components/KeepCard.vue';

export default {
  setup() {
    const route = useRoute();

    async function getProfileById() {
      try {
        let profileId = route.params.profileId;
        await profileService.getProfileById(profileId);
      }
      catch (error) {
        Pop.error(error.message);
      }
    }


    async function getVaultsByProfileId() {
      try {
        let profileId = route.params.profileId;
        await vaultService.getVaultsByProfileId(profileId);
      }
      catch (error) {
        Pop.error(error.message);
      }
    }

    async function getKeepsByProfileId() {
      try {
        let profileId = route.params.profileId
        await keepsService.getKeepsByProfileId(profileId)
      } catch (error) {
        Pop.error(error.message)
      }
    }

    watchEffect(() => {
      route.params.profileId;
      getProfileById();
      getVaultsByProfileId();
      getKeepsByProfileId();
    });

    return {
      account: computed(() => AppState.account),
      profiles: computed(() => AppState.profiles),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
    };
  },
  components: { VaultCard, KeepCard }
}
</script>


<style lang="scss" scoped></style>