const publishedFeedbacks = { template: '<publishedFeedbacks></publishedFeedbacks>' }


const router = new VueRouter({
	  mode: 'hash',
	  routes: [
		  { path: '/', name: 'publishedFeedbacks', component: publishedFeedbacks }
	  ]
});

var app = new Vue({
	router,
	el: '#careCureHospital'
});
