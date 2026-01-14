// window nesnesine doğrudan bağlayarak Blazor'ın bulmasını garanti ediyoruz
window.blazorCulture = {
    set: function (value) {
        const name = ".AspNetCore.Culture";
        const content = "c=" + value + "|uic=" + value;
        const date = new Date();
        date.setTime(date.getTime() + (365 * 24 * 60 * 60 * 1000));

        // Çerezi localhost'ta en uyumlu şekilde yazıyoruz
        document.cookie = name + "=" + content + ";expires=" + date.toUTCString() + ";path=/;SameSite=Lax";

        // "Local URL" hatasından kaçınmak için sunucuya gitmeden direkt sayfayı yeniliyoruz
        window.location.reload();
    }
};