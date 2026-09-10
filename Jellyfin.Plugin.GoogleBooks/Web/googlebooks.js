const GoogleBooksConfig = {
    pluginUniqueId: '7a9f4890-b216-4d75-a0e4-4c9f29ed5217'
};

export default function (view) {
    view.addEventListener('viewshow', function () {
        Dashboard.showLoadingMsg();
        const page = this;

        ApiClient.getPluginConfiguration(GoogleBooksConfig.pluginUniqueId).then(function (config) {
            page.querySelector('#apiKey').value = config.ApiKey || '';
            Dashboard.hideLoadingMsg();
        }).catch(function () {
            Dashboard.hideLoadingMsg();
            Dashboard.processErrorResponse({ statusText: 'Failed to load plugin configuration' });
        });
    });

    view.querySelector('#GoogleBooksConfigForm').addEventListener('submit', function (event) {
        event.preventDefault();
        Dashboard.showLoadingMsg();
        const form = this;

        ApiClient.getPluginConfiguration(GoogleBooksConfig.pluginUniqueId).then(function (config) {
            config.ApiKey = form.querySelector('#apiKey').value.trim();

            ApiClient.updatePluginConfiguration(GoogleBooksConfig.pluginUniqueId, config).then(function (result) {
                Dashboard.processPluginConfigurationUpdateResult(result);
            }).catch(function () {
                Dashboard.hideLoadingMsg();
                Dashboard.processErrorResponse({ statusText: 'Failed to update plugin configuration' });
            });
        }).catch(function () {
            Dashboard.hideLoadingMsg();
            Dashboard.processErrorResponse({ statusText: 'Failed to load plugin configuration' });
        });

        return false;
    });
}
