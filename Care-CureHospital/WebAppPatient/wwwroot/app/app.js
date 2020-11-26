const publishedFeedbacks = { template: '<publishedFeedbacks></publishedFeedbacks>' }
const patientsFeedbacks = { template: '<patientsFeedbacks></patientsFeedbacks>' }
const postFeedback = { template: '<postFeedback></postFeedback>' }
const patientRegistration = { template: '<patientRegistration></patientRegistration>' }
const surveyAfterExamination = { template: '<surveyAfterExamination></surveyAfterExamination>' }
const surveyResults = { template: '<surveyResults></surveyResults>' }
const medicalRecordReview = { template: '<medicalRecordReview></medicalRecordReview>' }
const patientDocumentsAdvancedSearch = { template: '<patientDocumentsAdvancedSearch></patientDocumentsAdvancedSearch>' }

const router = new VueRouter({
	mode: 'hash',
	routes: [
		{ path: '/', name: 'publishedFeedbacks', component: publishedFeedbacks },
		{ path: '/patientsFeedbacks', name: 'patientsFeedbacks', component: patientsFeedbacks },
		{ path: '/postFeedback', name: 'postFeedback', component: postFeedback },
		{ path: '/patientRegistration', name: 'patientRegistration', component: patientRegistration },
		{ path: '/surveyAfterExamination', name: 'surveyAfterExamination', component: surveyAfterExamination },
		{ path: '/surveyResults', name: 'surveyResults', component: surveyResults },
		{ path: '/medicalRecordReview', name: 'medicalRecordReview', component: medicalRecordReview },
		{ path: '/patientDocumentsAdvancedSearch', name: 'patientDocumentsAdvancedSearch', component: patientDocumentsAdvancedSearch }
	]
});

var app = new Vue({
	router,
	el: '#careCureHospital'
});
