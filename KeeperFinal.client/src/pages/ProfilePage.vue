<template>
  <div class="container-fluid text-center" v-if="vaults">
    <div class="cover-img"></div>
    <div class="row">
      <div class="col-12">
        <div class="profile-container">
          <img class="profile-picture" :src="profile.picture" alt="">
          <h1>{{ profile.name }}</h1>
          <div class="profile-stats">
            <div class="stats-item">
              <p>{{ vaults.length }}</p>
              <span>Vaults</span>
            </div>
            <div class="stats-item">
              <p>{{ keeps.length }}</p>
              <span>Keeps</span>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <h1>Vaults</h1>
      <div class="col-md-3 col-12 mb-3" v-for="vault in vaults" :key="vault.id">
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
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
    };
  },


  components: { VaultCard, KeepCard }
}
</script>


<style lang="scss" scoped>
.profile-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding-top: 100px;
  /* Adjust as needed */
}

.profile-picture {
  width: 150px;
  /* Adjust size as needed */
  height: 150px;
  border-radius: 50%;
  border: 3px solid white;
}

.profile-stats {
  display: flex;
  justify-content: center;
  margin-top: 20px;
}

.stats-item {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin: 0 20px;
}

.stats-item p {
  font-size: 24px;
  font-weight: bold;
  margin: 0;
}

.stats-item span {
  font-size: 14px;
  color: #999;
}
</style>