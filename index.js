Vue.createApp({
    data() {
        return {
            baseUrl: "https://waterflowapirest20230615101114.azurewebsites.net/api/waterflows",
            items: [],
            foundItem: {},
            addItemData: {id: 0, name: "", volume: 0},
            Id: 0,
            DateTime: "",
            idToFind: 0,
            Volume: 0,
            idItem: {},
            Name: "",
        }
    },
    async created() {
    await this.getAllItems();
  },
  methods: {
    async getAllItems() {
      try {
        const response = await axios.get(this.baseUrl);
        this.items = await response.data;
      } catch (ex) {
        alert(ex.message);
      }
    },
    async getById() {
        try {
            const response = await axios.get(this.baseUrl + "/" + this.idToFind);
            this.foundItem = await response.data;
        }
        catch (ex) {
            alert(ex.message + ". - Something went wrong and the entered id could not be found")
        }
    },
    async add() {
        try {
            response = await axios.post(this.baseUrl, this.addItemData)
            this.getAllItems()
        }
        catch (ex) {
            alert(ex.message)
        }
    },
}
    
}).mount("#app")