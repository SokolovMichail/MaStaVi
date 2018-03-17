library FF;

uses 
  System,
  System.Drawing,
  System.Windows.Forms, 
  System.Drawing.Drawing2D;

function ExtFloodFill(hdc: IntPtr; x, y: integer; color: integer; filltype: integer): boolean; external 'Gdi32.dll' name 'ExtFloodFill';

procedure FloodFill(x, y: integer; c: Color);
var
  hdc, hBrush, hOldBrush: IntPtr;
begin
  var borderColor: Color := GetPixel(x, y);
  //  var bc: integer := integer(borderColor.R) + (integer(borderColor.G) shl 8) + (integer(borderColor.B) shl 16);
  //  var cc: integer := integer(c.R) + (integer(c.G) shl 8) + (integer(c.B) shl 16);
  
  var bc := ColorTranslator.ToWin32(borderColor);
  var cc := ColorTranslator.ToWin32(c);
  
  hdc := gr.GetHDC();
  hBrush := CreateSolidBrush(cc);
  
  hOldBrush := SelectObject(hdc, hBrush);
  ExtFloodFill(hdc, x, y, bc, 1);
  SelectObject(hdc, holdBrush);
  
  var hbmp := bmp.GetHbitmap(); // Создается GDI Bitmap
  var memdc: IntPtr := CreateCompatibleDC(hdc);
  SelectObject(memdc, hbmp);
  
  hOldBrush := SelectObject(memdc, hBrush);
  ExtFloodFill(memdc, x, y, bc, 1);
  SelectObject(hdc, holdBrush);
  
  var bmp1 := Bitmap.FromHbitmap(hbmp);
  gbmp.DrawImage(bmp1, 0, 0);
  
  bmp1.Dispose();
  //  bmp := Bitmap.FromHbitmap(hbmp);
  
  DeleteObject(memdc);
  DeleteObject(hbmp);
  DeleteObject(hBrush);
  
  gr.ReleaseHdc();
  
  DeleteObject(hdc);
end;

end.