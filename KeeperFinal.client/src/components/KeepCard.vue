<template>
  <div v-if="keepProp" @click="setActiveKeep(keepProp)" data-bs-toggle="modal" data-bs-target="#keepDetails"
    class="keep-card">
    <div class="keep-image" :style="{ backgroundImage: 'url(' + keepProp.img + ')' }">
      <h3 class="keep-name elevation">{{ keepProp.name }}</h3>
      <router-link :to="{ name: 'Profile', params: { profileId: keepProp.creator.id } }">
        <img :src="keepProp.creator.picture" class="keep-profile">
      </router-link>
      <div v-if="keepProp.creator.id === account.id">
        <i @click.stop="removeKeep(keepProp)" class="mdi mdi-delete-circle add-button me-2" title="DELETE"></i>
      </div>

    </div>
  </div>
</template>

<script>
import { computed } from 'vue';
import { Keep } from '../models/Keep.js';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';

export default {

  props: {
    keepProp: { type: Keep, require: true }
  },
  setup() {



    return {
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account),

      setActiveKeep(keep) {
        try {
          keepsService.setActiveKeep(keep)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      },

      async removeKeep(keep) {
        try {
          const confirmDelete = await Pop.confirm('Delete This Keep?');
          if (confirmDelete) {
            await keepsService.removeKeep(keep.id);
          }
        } catch (error) {
          Pop.error(error.message);
        }
      }
    }
  },



}
</script>


<style lang="scss" scoped>
.keep-card {
  cursor: pointer;
  display: flex;
  flex-direction: column;
  align-items: center;
  background-color: #f5f5f5;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(134, 52, 52, 0.1);
  transition: transform 0.2s, box-shadow 0.2s;
}

.add-button {
  position: absolute;
  right: -15px;
  bottom: 95%;
  transform: translateY(-50%);
  cursor: pointer;
}

.keep-name {
  position: absolute;
  bottom: 10px;
  left: 10px;
  color: white;
  padding: 5px 10px;
  font-weight: bold;
  border-radius: 5px;
}

.keep-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.keep-image {
  width: 100%;
  padding-top: 75%;
  background-size: cover;
  position: relative;
}

.keep-info {
  padding: 16px;
  text-align: center;
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