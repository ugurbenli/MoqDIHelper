# Moq DI Helper

Diğer Diller / Other languages : <a href='https://github.com/ugurbenli/MoqDIHelper/blob/master/README-EN.md'>EN<a/>

<h3>Proje Amacı</h3>

<p>Unit Test için yer alan <b>Mock</b> kütüphanelerinden olan <b>Moq</b> kütüphanesinde kullanılmak için yazılmış, Dependency Injection (DI) yapısının bu kütüphanede işlemesini sağlayan service helper classı örnek projesidir. Bu class önceki cümlede de belirtildiği gibi <b>Moq</b> kütüphanesindeki servislerin tıpkı DI kütüphaneleri olan Castler Windsor, Ninject vb. gibi Dependency Injection yapısında tutulmasını ve yönetimini sağlar.</p>

<h3>Proje bağımlılıkları</h3>

- ASP. NET Core 3.1 >=
- NUnit 3.12.0 >=
- Moq 4.13.1 >=

<h3>Proje Detay</h3>

<p>Test projesinde yer alan testleri inceleyerek kurulan yapıyla ilgili fikir sahibi olabilirsiniz. Basitçe anlatmak gerekirse bir Customer servisi ve ona ait testler yer almaktadır. Dummy olarak eklenen iki de fake servis yer almaktadır. Bu servisler <b>Mock</b> kullanımına örnek olsun diye eklenmiştir.</p>
