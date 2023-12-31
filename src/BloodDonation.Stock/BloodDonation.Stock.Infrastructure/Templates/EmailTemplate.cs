﻿using BloodDonation.Stock.Core.Models.DTOs;
using System.Text;

namespace BloodDonation.Stock.Infrastructure.Templates
{
    public class EmailTemplate
    {
        public const string Subject = "Estoque de Sangue";

        public static string Body(IEnumerable<BloodStockDTO> stock) =>
            $@"
<html>
<body>
    <p>Prezado(a) Administrador(a),</p>

    <p>Abaixo segue a lista de estoque de sangue:</p>

    <table border=""1"">
        <tr>
            <td>Tipo</td>
            <td>Quantidade</td>
        </tr>
        <tr>
            {GenerateTable(stock)}
        </tr>
    </table>
</body>
<b>Atenciosamente,</b><br />
<p>Equipe de Desenvolvimento</p>
</html>";

        private static StringBuilder GenerateTable(IEnumerable<BloodStockDTO> stock) => stock.Aggregate(new StringBuilder(), (sb, s) => sb.AppendLine(GenerateLine(s)));

        private static string GenerateLine(BloodStockDTO stock) => $@"<tr><td>{stock.BloodType}</td><td>{stock.QuantityMl} Ml</td></tr>";
    }
}
