const publishedFeedbacks = { template: '<publishedFeedbacks></publishedFeedbacks>' }
const patientsFeedbacks = { template: '<patientsFeedbacks></patientsFeedbacks>' }
const postFeedback = { template: '<postFeedback></postFeedback>' }
const patientRegistration = { template: '<patientRegistration></patientRegistration>' }

const router = new VueRouter({
	mode: 'hash',
	routes: [
		{ path: '/', name: 'publishedFeedbacks', component: publishedFeedbacks },
		{ path: '/patientsFeedbacks', name: 'patientsFeedbacks', component: patientsFeedbacks },
		{ path: '/postFeedback', name: 'postFeedback', component: postFeedback },
		{ path: '/patientRegistration', name: 'patientRegistration', component: patientRegistration }
	]
});

var app = new Vue({
	router,
	el: '#careCureHospital'
});
