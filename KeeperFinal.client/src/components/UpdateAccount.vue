<template>
  <div class="col-6 mb-4 text-white">
    <p>Edit Account</p>
    <form action="" @submit.prevent="editAccount()">
      <div class="mb-2">
        <label for="name">Name</label>
        <input class="form-control" type="text" id="name" minlength="3" maxlength="75" v-model="editable.name">
      </div>
      <div class="mb-2">
        <label for="email">Email</label>
        <input v-model="editable.email" type="text" class="form-control" name="email" id="email">
      </div>
      <div class="mb-2">
        <label for="picture">Picture</label>
        <input class="form-control" type="url" id="picture" minlength="3" maxlength="200" v-model="editable.picture">
      </div>
      <button type="submit">Update</button>
    </form>
  </div>
</template>


<script>
import { computed, ref } from 'vue'
import { AppState } from '../AppState.js'
import { accountService } from '../services/AccountService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { Modal } from "bootstrap"

export default {
  setup() {
    const account = ref({})
    const editable = ref({})





    return {
      editable,
      account: computed(() => AppState.account),






      async editAccount() {
        try {
          const formData = editable.value
          await accountService.editAccount(formData)
          logger.log('[EDITING ACCOUNT]', editable)
          Modal.getOrCreateInstance('#editAccount').hide()
        } catch (error) {
          Pop.error(error.message)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>